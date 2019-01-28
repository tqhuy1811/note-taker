<template >
  <div>
    <create-post :bus=bus @create-post="createPost"  />
    <div class="container">
      <div class="columns is-multiline">
        <div class="column is-12">
          <h2 class="has-text-centered has-text-dark is-title">Random text to fill out blank space. Because why not ¯\_(ツ)_/¯</h2>  
        </div>
        <div class="column is-12">
          <div class="columns is-centered">
            <div class="column is-6 column-spacing">
              <SearchInput @search-complete="searchComplete" />
            </div>
          </div>
        </div>
        <div class="column is-4">
          <div class="columns is-multiline column-spacing">
            <div class="column is-12">
              <button 
                class="button is-primary is-rounded  is-fullwidth" 
                id="add-note"
                v-on:click="triggerPopup"
              >
                Add New Note
              </button>
            </div>
            <div v-for="language in languages" v-bind:key="language.getId()" class="column is-12">
              <Card type="language" :onDeleteClick="onDeleteClick" :onCardClick="onCardClick"  :item="language" />
            </div>
          </div>
        </div>
        <div id="scrollable" v-if="notes.length !== 0" class="column is-8 is-hidden-mobile">
          <div class="columns is-multiline column-spacing">
            <div v-for="note in notes" v-bind:key="note.id" class="column is-12">
              <Card :item="note" type="note" />
            </div>
          </div>
        </div>
        <div class="column is-4">

        </div>
        <div v-if="shouldDisplayLoadMore" class="column is-8">
          <button @click="onLoadMoreClick" class="button is-info">Load more</button>
        </div>
      </div>
    </div>

  </div>
</template>


<script lang="ts">

import Vue from 'vue';
import Card from './components/Card.vue';
import SearchInput from './components/SearchInput.vue';
import CreatePost from './components/CreatePost.vue';
import Language from './models/ProgrammingLanguage';
import Note from './models/Note';
import axios from 'axios';


export default Vue.extend({
  components: {
    Card,
    SearchInput,
    CreatePost
  },
  mounted() {
    axios.get(`${this.$api}/language`).then((res: any) => {
      this.languages = res.data.map((el: any) => new Language(el.title, el.languageId));
    }).catch((err: any) => {
      this.$router.push('/error');
    })
  },
 
	data () {
		return {
      bus: new Vue(),
      languages:[] as Language[],
      notes: [] as Note[],
      currentLanguageId: 0 ,
      shouldDisplayLoadMore: false
		}
	},
  methods: {
    onCardClick: function(id: number) {
      this.currentLanguageId = id;
      axios.get(`${this.$api}/note?languageId=${id}`).then((res: any) => {
        this.notes = res.data.map((el: any) => new Note(el.title, el.content, el.noteID ));
        if(this.notes.length === 5){
          this.shouldDisplayLoadMore = true;
        }else {
          this.shouldDisplayLoadMore = false; 
        }
      }).catch((err: any) => {
        this.$router.push('/error');
      })
    },
    onDeleteClick: function(id: number) {
      axios.delete(`${this.$api}/language/${id}`).then((res: any) => {
        this.languages = this.languages.filter(el => el.getId() !== id);
        this.notes = [] as Note[];
      }).catch((err: any) => {
				this.$router.push('/error');
      })
    },
    searchComplete: function(result: any) {
      if(result.length !== 0){
        this.languages = result.map((el: any) => new Language(el.title, el.languageId));
        this.notes = [];
      }
    },
    createPost: function(language: Language){
      this.languages.push(language);
    },

    onLoadMoreClick: function() { 
      axios.get(`${this.$api}/note?languageId=${this.currentLanguageId}&skipItem=${this.notes.length}`).then((res: any) => {
        if(res.data.length !== 0){
          res.data.forEach((element: any) => {
            let note = new Note(element.title, element.content, element.noteID);
            this.notes.push(note);
          });
        }else{
          this.shouldDisplayLoadMore = false 
        }
      }).catch((err: any) => {
        this.$router.push('/error');

      })
    },
    triggerPopup: function() {
			this.bus.$emit('trigger-popup');
    }, 
  },
});
</script>




<style>
  .is-info {
    margin-left: 18px
  }
  #scrollable {
    height: 800px;
    overflow: auto
  }
  #add-note {
    margin-bottom: -10px;
  }
  .container {
    padding: 20px;
  }
  .has-text-centered {
    font-size: 20px
  }
  .column-spacing {
    padding: 20px
  }
</style>
