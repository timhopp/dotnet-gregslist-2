import Vue from "vue";
import Router from "vue-router";
import Home from "../views/Home.vue";
import Cars from "../views/Cars.vue";
import Car from "../views/Car.vue";
import { authGuard } from "@bcwdev/auth0-vue";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "home",
      component: Home,
    },
    {
      path: "/cars",
      name: "cars",
      component: Cars,
      beforeEnter: authGuard,
    },
    {
      path: "/car/:carId",
      name: "car",
      component: Car,
    },
    {
      path: "*",
      redirect: "/",
    },
  ],
});
