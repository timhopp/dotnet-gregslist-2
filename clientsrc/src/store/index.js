import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router/index";

Vue.use(Vuex);

//Allows axios to work locally or live
let base = window.location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: base + "api/",
  timeout: 3000,
  withCredentials: true,
});

export default new Vuex.Store({
  state: {
    user: {},
    cars: [],
    activeCar: {},
  },
  mutations: {
    setCars(state, cars) {
      state.cars = cars;
    },
    setUser(state, user) {
      state.user = user;
    },
    setActiveCar(state, foundcar) {
      state.activeCar = foundcar;
    },
  },
  actions: {
    //#region -- AUTH STUFF --
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    //#endregion

    async addCar({ dispatch }, carData) {
      try {
        let res = await api.post("cars", carData);
        dispatch("getCars");
      } catch (error) {
        console.error(error);
      }
    },
    getCars({ commit }) {
      api.get("cars").then((res) => commit("setCars", res.data));
    },
    getActiveCar({ commit, dispatch, state }, carId) {
      // let foundCar = this.state.cars.find((car) => carId == car.id);
      let foundCar = this.state.cars();
      commit("setActiveCar", foundCar);
    },
  },
});
