import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Profile from './views/Profile.vue'
// @ts-ignore
import Vault from './views/Vault.vue'
// @ts-ignore
import Keep from './views/Keep.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/profile',
      name: 'profile',
      component: Profile
    },
    {
      path: '/vault/:id',
      name: 'vault',
      component: Vault
    },
    {
      path: '/keep/:keepId',
      name: 'keep',
      component: Keep
    }
  ]
})
