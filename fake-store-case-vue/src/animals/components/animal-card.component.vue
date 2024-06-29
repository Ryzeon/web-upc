<script>
import {Animal} from "../model/animal.entity.js";

export default {
  name: "animal-card",
  props: {
    animal: Animal
  }
}
</script>

<template>
  <pv-card style="overflow: hidden" class="m-2" :arial-label="animal.name + 'Card'">
    <template #header>
      <div class="flex align-items-center justify-content-center">
        <img :alt="animal.name" :src="animal.image" class="w-7"/>
      </div>

    </template>
    <template #title>
      {{ animal.name }}
    </template>
    <template #subtitle>
      <br>
      <hr>
      <div aria-label="Animal Info">
        <p>
          Species: {{ animal.species }}<br/>
          Family: {{ animal.family }} <br/>
        </p>
        <p>
          Habitat: {{ animal.habitat }}<br/>
          Place of Found: {{ animal.place_of_found }}<br/>
        </p>
      </div>
      <hr>
    </template>
    <template #content>
      <p class="m-0" aria-label="Description">
        {{ animal.description }}
      </p>
      <br>
      <div aria-label="Additional Info">
        <span class="font-bold">Diet:</span> {{ animal.diet }}<br/>
        <span class="font-bold">Weight:</span> {{ animal.weight_kg }} kg<br/>
        <span class="font-bold">Height:</span> {{ animal.height_cm }} cm
      </div>

    </template>
  </pv-card>
</template>