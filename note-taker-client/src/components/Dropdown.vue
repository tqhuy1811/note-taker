<template>
	<div class="dropdown" id="dropdown">
		<div class="dropdown-trigger">
			<button v-on:click="handleDropdown" class="button" aria-haspopup="true" aria-controls="dropdown-menu4">
				<span>{{ selectedItem }}</span>
				<span class="icon is-small">
					<i class="fa fa-angle-down" aria-hidden="true"></i>
				</span>
			</button>
		</div>
		<div class="dropdown-menu" id="dropdown-menu4" role="menu">
			<div class="dropdown-content">
				<div class="dropdown-item" v-on:click="dropDownItemClick(index)" v-bind:key="index" v-for="(item,index) in dropdownItems">
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
		props: {
		dropdownItems: {
			type: Array as () => Array<string>,
			required: true
		},
		bus: Object
	},
	data: function() {
		return {
			selectedItem: this.dropdownItems[0],
		}
	},
	
	methods: {
		dropDownItemClick: function (id: number) {
			this.handleDropdown();
			this.selectedItem = this.dropdownItems[id]
			this.$emit('item-select',this.dropdownItems[id]);
		},
		handleDropdown: function() {
			const dropdown = document.getElementById('dropdown');
			if(dropdown)
				switch(dropdown.className){
					case 'dropdown':
						dropdown.className = 'dropdown is-active';
						break;
					case 'dropdown is-active':
						dropdown.className = 'dropdown';
						break;
					default:
						break;
				}
		},
		resetDropdown: function() {
			const dropdown = document.getElementById('dropdown');
			this.selectedItem = this.dropdownItems[0];
			this.$emit('item-select',this.dropdownItems[0]);
			if(dropdown)
				dropdown.className = 'dropdown';
		},
	},	
	created() {
		this.bus.$on('trigger-popup', this.resetDropdown);
	},
});
</script>
<style>
	.dropdown-item {
		cursor: pointer;
	}
</style>


