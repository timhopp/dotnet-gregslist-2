<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-light">
    <router-link class="navbar-brand" :to="{ name: 'home' }"
      >Kanban</router-link
    >
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav mr-auto">
        <li class="nav-item" :class="{ active: $route.name == 'home' }">
          <router-link :to="{ name: 'home' }" class="nav-link"
            >Home</router-link
          >
        </li>
        <li class="nav-item" :class="{ active: $route.name == 'cars' }">
          <router-link :to="{ name: 'cars' }" class="nav-link"
            >Cars</router-link
          >
        </li>
      </ul>
      <span class="navbar-text">
        <button
          class="btn btn-success"
          @click="login"
          v-if="!$auth.isAuthenticated"
        >
          Login
        </button>
        <button class="btn btn-danger" @click="logout" v-else>logout</button>
      </span>
    </div>
  </nav>
</template>

<script>
import axios from "axios";

let _api = axios.create({
  baseURL: "https://localhost:5001",
  withCredentials: true,
});
export default {
  name: "Navbar",
  methods: {
    async login() {
      await this.$auth.loginWithPopup();
      if (this.$auth.isAuthenticated) {
        this.$store.dispatch("setBearer", this.$auth.bearer);
        this.$store.dispatch("getProfile");
      }
    },
    async logout() {
      await this.$auth.logout({ returnTo: window.location.origin });
    },
  },
};
</script>

<style></style>
