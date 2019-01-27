<template>
	<div class="modal" id="modal-popup">
		<div 
			class="modal-background" 
			v-on:click="popUpHandler"
		>
		</div>
			<div class="modal-card">
				<header class="modal-card-head">
					<p class="modal-card-title">Create something will you ?</p>
					<button 
						class="delete" 
						aria-label="close"
						v-on:click="popUpHandler"
					>
					</button>
				</header>
				<section class="modal-card-body">
					<div class="columns  is-multiline">
						<div class="column is-4">
							<dropdown :bus="bus" v-on:item-select="dropDownItemClick" :dropdownItems="dropdownItems"/>
						</div>
						<div class="column is-12">
							<input placeholder="Enter title" type="text" v-model="title" class="input">
						</div>
						<div class="column is-12" v-if="currentSelectItem === 'Note'">
							<input placeholder="Enter language id" class="input" v-model="languageId"/>
						</div>
						<div class="column is-12" v-if="currentSelectItem === 'Note'">
							
							<textarea placeholder="Enter body content" class="textarea" v-model="content"/>
						</div>
					</div>
					
					<!-- Content ... -->
				</section>
				<footer class="modal-card-foot">
					<button @click="onSavePost" class="button is-success">Save Post</button>
				</footer>
			</div>
	</div>
</template>


<script lang="ts">
import Vue from 'vue';
import Dropdown from './Dropdown.vue';
import axios from 'axios';
import ProgrammingLanguage from '@/models/ProgrammingLanguage';

export default Vue.extend({
	name: 'create-post',
	props: ['bus'],
	data() {
		return {
			content: '',
			title:'',
			languageId: '',
			currentSelectItem:'Programming Language',
			dropdownItems: ['Programming Language', 'Note'],
		};
	},
	components: {
		Dropdown,
	},
	methods: {
		popUpHandler: function() {
			const modal = document.getElementById('modal-popup');
			if(modal)
				switch(modal.className){
					case 'modal':
						modal.className = 'modal is-active';
						break;
					case 'modal is-active':
						modal.className = 'modal';
						break;
					default:
						break;
				};
		},
		onSavePost: function() {
			if(this.currentSelectItem === 'Programming Language') {
				axios.post(`${this.$api}/language`,{
					title: this.title
				}).then(res => {
					this.$emit('create-post', this.title);
				}).catch(err => {
					this.$router.push('/error');
				})
			}else{
				axios.post(`${this.$api}/note`,{
					title: this.title,
					content: this.content,
					languageId: this.languageId
				}).then(res => {
				}).catch(err => {
					this.$router.push('/error');
				})
			}
		},
		dropDownItemClick: function(currentSelectItem: string) {
			this.currentSelectItem = currentSelectItem;
		}
	},
	created() {
		this.bus.$on('trigger-popup', this.popUpHandler);
	},

});
</script>




