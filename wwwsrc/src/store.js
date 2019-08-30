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
    userVaults: {},
    activeVault: {},
    activeKeep: {},
    keepsByVault: []
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
    },
    setActiveVault(state, data) {
      state.activeVault = data
    },
    setActiveKeep(state, data) {
      state.activeKeep = data
    },
    setKeepsByVault(state, data) {
      state.keepsByVault = data
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
        // console.log(res.data)
      } catch (error) {
        console.error(error)
      }
    },
    async getUserKeeps({ dispatch, commit }) {
      try {
        let res = await api.get('keeps/user')
        commit('setUserKeeps', res.data)
        // console.log(res.data)
      } catch (error) {
        console.error(error)
      }
    },
    async getUserVaults({ dispatch, commit }) {
      try {
        let res = await api.get('vaults')
        commit('setUserVaults', res.data)
        // console.log(res.data)
      } catch (error) {
        console.error(error)
      }
    },
    async deleteKeepById({ dispatch, commit }, payload) {
      try {
        let data = await api.delete('keeps/' + payload)
        dispatch('getUserKeeps')
      } catch (error) {
        console.error(error)
      }
    },
    async deleteVaultById({ dispatch, commit }, payload) {
      try {
        let data = await api.delete('vaults/' + payload)
        dispatch('getUserVaults')
      } catch (error) {
        console.error(error)
      }
    },
    async addCreatedKeep({ dispatch, commit }, payload) {
      try {
        let res = await api.post('keeps/', payload)
        dispatch('getUserKeeps')
      } catch (error) {
        console.error(error)
      }
    },
    async addCreatedVault({ dispatch, commit }, payload) {
      try {
        let res = await api.post('vaults/', payload)
        dispatch('getUserVaults')
      } catch (error) {
        console.error(error)
      }
    },
    async getActiveVault({ dispatch, commit }, payload) {
      try {
        let res = await api.get('vaults/' + payload.id)
        commit('setActiveVault', res.data)
        // console.log(payload.id)
      } catch (error) {
        console.error(error)
      }
    },
    async getActiveKeep({ dispatch, commit }, payload) {
      try {
        let res = await api.get('keeps/' + payload.id)
        commit('setActiveKeep', res.data)
        // console.log(payload.id)
      } catch (error) {
        console.error(error)
      }
    },
    async addKeepToVault({ dispatch, commit }, payload) {
      try {
        let res = await api.post('vaultkeeps/', payload)
        dispatch('getKeepsByVaultId')
      } catch (error) {
        console.error(error)
      }
    },
    async getKeepsByVaultId({ dispatch, commit }, payload) {
      try {
        let res = await api.get('vaultkeeps/' + payload.id, payload.id)
        commit('setKeepsByVault', res.data)
        console.log(res.data)
      } catch (error) {
        console.error(error)
      }
    }
  }
})
