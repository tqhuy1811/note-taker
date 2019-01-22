<template>
	<div class="dropdown is-hoverable">
		<div class="dropdown-trigger">
			<button class="button" aria-haspopup="true" aria-controls="dropdown-menu4">
				<span>Choose Something</span>
				<span class="icon is-small">
					<i class="fa fa-angle-down" aria-hidden="true"></i>
				</span>
			</button>
		</div>
		<div class="dropdown-menu" id="dropdown-menu4" role="menu">
			<div class="dropdown-content">
				<div class="dropdown-item" v-bind:key="item" v-for="item in dropdownItems">
					{{ item }}
				</div>
			</div>
		</div>
	</div>
</template>
<script lang="ts">
import Vue from 'vue';
export default Vue.extend({
	name: 'dropdown',
	props: ['dropdownItems'],
});
</script>
<style>
	.dropdown-item {
		cursor: pointer;
	}
</style>


