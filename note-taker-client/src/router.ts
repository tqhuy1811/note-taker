import Vue from 'vue';
import Router from 'vue-router';
import App from './App.vue';
import Error from './views/Error.vue';

Vue.use(Router);

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'main',
      component: App,
    },
    {
      path: '/error',
      name: 'error',
      component: Error
    },
  ],
});
