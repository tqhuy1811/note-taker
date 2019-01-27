import Vue from 'vue';
// import App from './App.vue';
import Main from './Main.vue'
import router from './router';
import store from './store';

Vue.config.productionTip = false;

declare module 'vue/types/vue' {
  interface Vue {
    $api: String
  }
}

if(process.env.NODE_ENV === 'development'){
  Vue.prototype.$api = 'http://localhost:5000/api';
}




new Vue({
  router,
  store,
  render: (h) => h(Main),
}).$mount('#app');
