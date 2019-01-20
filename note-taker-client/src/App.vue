<template >
  <div class="main-app-theme">
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
            <div v-for="n in 10" v-bind:key="n" class="column is-12">
              <Card />
            </div>
          </div>
        </div>
        <div class="column is-8 is-hidden-mobile">
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

export default Vue.extend({
  components: {
    Card,
    SearchInput,
  },
});
</script>




<style>
  .main-app-theme {
    background-color: whitesmoke
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
