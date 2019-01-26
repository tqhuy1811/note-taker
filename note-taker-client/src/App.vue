<template >
  <div>
    <create-post :bus=bus />
    <div class="container">
      <div class="columns is-multiline">
        <div class="column is-12">
          <h2 class="has-text-centered has-text-dark is-title">Random text to fill out blank space. Because why not ¯\_(ツ)_/¯</h2>  
        </div>
        <div class="column is-12">
          <div class="columns is-centered">
            <div class="column is-6 column-spacing">
              <SearchInput />
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
        <div v-if="notes.length !== 0" class="column is-8 is-hidden-mobile">
          <div class="columns is-multiline column-spacing">
            <div v-for="n in 10" v-bind:key="n" class="column is-12">
              <Card />
            </div>
          </div>
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
    // axios.get('http://localhost:5000/api/language').then(res => {
    //   this.languages = res.data.map((el: any) => new Language(el.title, el.languageId ));
    // }).catch(err => {
    //   console.log(err);
    // })
  },
 
	data () {
		return {
      bus: new Vue(),
      languages:[ new Language("C#", 1)],
      notes:[]
		}
	},
  methods: {
    onCardClick: function(id: number) {
      console.log(id);
    },
    onDeleteClick: function(id: number) {
      console.log(id);
    },
    triggerPopup: function() {
			this.bus.$emit('trigger-popup');
    }, 
  },
});
</script>




<style>

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
