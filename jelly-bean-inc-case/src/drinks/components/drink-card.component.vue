<script>
import {Drink} from "../model/drink.entity.js";

export default {
  name: "drink-card",
  props: {
    drink: Drink
  },
  methods: {
    getNiceIngredients() {
      return this.drink.ingredients.join(", ");
    }
  }
}
</script>

<template>
  <pv-card style="overflow: hidden" class="m-2">
    <template #header>
      <div class="flex align-items-center justify-content-center">
        <img :alt="drink.flavorName" :src="drink.imageUrl" class="w-7"/>
      </div>

    </template>
    <template #title>
      {{ drink.flavorName }}
    </template>
    <template #subtitle>
      <p>
        Ingredients: {{ getNiceIngredients() }}
      </p>
      <p>
        Kosher: {{ drink.kosher ? "Yes" : "No" }},
        Gluten Free: {{ drink.glutenFree ? "Yes" : "No" }},
        Sugar Free: {{ drink.sugarFree ? "Yes" : "No" }},
        Seasonal: {{ drink.seasonal ? "Yes" : "No" }}
      </p>

    </template>
    <template #content>
      <p class="m-0">
        {{ drink.description }}
      </p>
    </template>
  </pv-card>
</template>

<style scoped>

</style>