<template>
  <div class="cars text-white">
    These Are Your Cars
    <form @submit.prevent="addCar">
      <label for>Make</label>
      <input type="text" placeholder="Make" v-model="newCar.make" required />
      <label for>Model</label>
      <input type="text" placeholder="Model" v-model="newCar.model" />
      <label for>Year</label>
      <input type="number" placeholder="Year" v-model="newCar.year" />
      <label for>Price</label>
      <input type="numer" placeholder="Price" v-model="newCar.price" />
      <label for>Description</label>
      <input type="text" placehold="Description" v-model="newCar.description" />
      <label for>Image</label>
      <input type="text" placeholder="Image url" v-model="newCar.imgUrl" />
      <button class="btn btn-outline-submit" type="submit">Create Car</button>
    </form>
    <div v-for="car in cars" :key="car.id">
      <router-link :to="{ name: 'car', params: { carId: car.id } }"
        >{{ car.make }} {{ car.model }} {{ car.description }}</router-link
      >
    </div>
  </div>
</template>

<script>
export default {
  name: "cars",
  data() {
    return {
      newCar: {},
    };
  },
  mounted() {
    this.$store.dispatch("getCars");
  },
  computed: {
    cars() {
      return this.$store.state.cars;
    },
  },
  methods: {
    addCar() {
      this.newCar.year = +this.newCar.year;
      this.newCar.price = +this.newCar.price;
      this.$store.dispatch("addCar", this.newCar);
      this.newCar = {};
    },
    setActiveCar(carId) {
      this.$store.dispatch("setActiveCar", carId);
      console.log("hit");
    },
  },
  components: {},
};
</script>

<style scoped></style>
