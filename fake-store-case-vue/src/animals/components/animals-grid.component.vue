<script>
import {AnimalApiService} from "../service/animal-api.service.js";
import {Animal} from "../model/animal.entity.js";
import AnimalCard from "./animal-card.component.vue";

export default {
  name: "animals-grid",
  components: {AnimalCard},
  data() {
    return {
      animals: [],
      animalsApi: new AnimalApiService()
    }
  },
  created() {
    this.fetchAnimals();
  },
  methods: {
    buildAnimalListFromResponseData(response) {
      return response.map(animal => {
        return new Animal(
            animal.id,
            animal.name,
            animal.species,
            animal.family,
            animal.habitat,
            animal.place_of_found,
            animal.diet,
            animal.description,
            animal.weight_kg,
            animal.height_cm,
            animal.image
        )
      });
    },
    fetchAnimals() {
      this.animalsApi.getAllAnimals().then(response => {
        let animals = response.data;
        this.animals = this.buildAnimalListFromResponseData(animals);
        console.log(this.animals);
      }).catch(error => {
        console.error(error);
      });
    }
  },
}
</script>

<template>
  <div class="grid">
    <div class="col-6" v-for="animal in animals" :key="animal.id" aria-label="Animal Info">
      <animal-card class="mt-4" :animal="animal"/>
    </div>
  </div>
</template>