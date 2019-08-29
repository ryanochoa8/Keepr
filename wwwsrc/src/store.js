import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    publicKeeps: {},
    userKeeps: {},
    userVaults: {}
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },
    setPublicKeeps(state, data) {
      state.publicKeeps = data
    },
    setUserKeeps(state, data) {
      state.userKeeps = data
    },
    setUserVaults(state, data) {
      state.userVaults = data
    }
  },
  actions: {

    //#region -- Auth stuff --
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "login" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    //#endregion

    async getPublicKeeps({ dispatch, commit }) {
      try {
        let res = await api.get('keeps/')
        commit('setPublicKeeps', res.data)
        console.log(res.data)
      } catch (error) {
        console.error(error)
      }
    },
    async getUserKeeps({ dispatch, commit }) {
      try {
        let res = await api.get('keeps/user')
        commit('setUserKeeps', res.data)
        console.log(res.data)
      } catch (error) {
        console.error(error)
      }
    },
    async getUserVaults({ dispatch, commit }) {
      try {
        let res = await api.get('vaults')
        commit('setUserVaults', res.data)
        console.log(res.data)
      } catch (error) {
        console.error(error)
      }
    }
  }
})
