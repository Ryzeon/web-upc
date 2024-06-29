<script>
import {defineComponent} from "vue";
import FooterContent from "./public/footer-content.component.vue";
import DrinkCard from "./drinks/components/drink-card.component.vue";
import {DrinksApiService} from "./drinks/service/drinks-api.service.js";
import {Drink} from "./drinks/model/drink.entity.js";
import DrinkGrid from "./drinks/components/drink-grid.component.vue";

export default defineComponent({
  components: {DrinkGrid, DrinkCard, FooterContent},
  data() {
    return {
      drinks: [],
      drinksApi: new DrinksApiService()
    }
  },
  created() {
    this.getDrinks();
  },
  methods: {
    buildDrinksListFromResponseData(items) {
      return items.map(item => {
        return new Drink(
            item.beanId,
            item.backgroundColor,
            item.ingredients,
            item.flavorName,
            item.description,
            item.imageUrl,
            item.glutenFree,
            item.sugarFree,
            item.seasonal,
            item.kosher
        )
      })
    },
    getDrinks() {
      this.drinksApi.getDrinks().then(response => {
        let items = response.data.items;
        this.drinks = this.buildDrinksListFromResponseData(items);
        console.log(this.drinks)
      }).catch(e => {
        console.error(e);
      })
    }
  }
})
</script>

<template>
  <pv-toast/>
  <header aria-label="header-component">
    <!--  w-full -> 100% width -->
    <div class="w-full">
      <pv-toolbar class="bg-primary">
        <template #start>
          <h1>Jelly Bean Peru Store.</h1>
        </template>
      </pv-toolbar>
    </div>
  </header>
  <div>
    <drink-grid :drinks="drinks"/>
  </div>
  <footer-content/>
</template>