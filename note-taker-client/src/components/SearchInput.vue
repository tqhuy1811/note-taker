<template>
  <div class="field">
    <div class="control has-icons-right">
      <input 
        class="input is-rounded" 
        v-model="searchString" 
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
export default Vue.extend({
  name: 'search-input',
  data() {
    return {
      searchString: '',
    };
  },
});
</script>

