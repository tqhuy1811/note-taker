<template>
  <div  class="card" >
    <header class="card-header" v-on:click="onCardClick(item.getId())">
      <p v-if="type === 'language'" class="card-header-title custom-title">
        {{ this.item.getTitle() }} { {{ this.item.getId() }} }
      </p>
      <p v-else-if="type === 'note'" class="card-header-title">
        {{ this.item.getContent() }}
      </p>
      <div v-if="type === 'language'" class="card-header-icon" aria-label="more options">
        <button v-on:click.stop="onDeleteClick(item.getId())" class="delete"></button>
      </div>
    </header>
    <div v-if="item.content" class="card-content">
      <div class="content">
        {{ this.item.getTitle() }}
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
export default Vue.extend({
  name: 'card-component',
  props: {
    item: {
      type: Object,
    },
    type: {
      type: String
    },
    onCardClick: {
      type: Function,
      default: function() {
        return;
      }
    },
    onDeleteClick: {
      type: Function,
      default: function() {
        return;
      }
    }
  },
});
</script>

<style>
  .custom-title {
    font-size: 30px;
    text-align: center
  }
</style>



