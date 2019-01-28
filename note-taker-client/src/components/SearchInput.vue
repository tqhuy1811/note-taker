<template>
  <div class="field">
    <div class="control has-icons-right">
      <input 
        class="input is-rounded" 
        v-model="searchString" 
        v-on:keydown.13="onSearchEnter"
        placeholder="Type me to search stuff"
      />
      <span class="icon is-small is-right">
        <i class="fa fa-search"></i>
      </span>
    </div>
  </div>
</template>


<script lang="ts">
import Vue from 'vue';
import axios from 'axios';
export default Vue.extend({
  name: 'search-input',
  data() {
    return {
      searchString: '',
    };
  },
  methods: {
    onSearchEnter: function() {
      axios.get(`${this.$api}/search?languageName=${this.searchString}`).then(res => {
        this.$emit('search-complete', res.data);
      }).catch(err => {
        this.$router.push('/error');
      })
    }
  },
});
</script>

