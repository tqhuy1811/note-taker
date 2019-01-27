<template>
  <div class="container">
    <p class="error-message">
      SOMETHING WENT WRONG ! PROBABLY BECAUSE OF THE SHITTY SERVER !
    </p>
  </div>
</template>


<script lang="ts">
import Vue from 'vue';
export default Vue.extend({
  name: 'error',
})
</script>




<style>
  .error-message {
    text-align: center;
    color: teal;
    font-size: 30px
  }
</style>

