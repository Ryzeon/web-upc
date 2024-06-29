<script>
import LanguageSwitcher from "./language-switcher.component.vue";

export default {
  name: "toolbar-content",
  components: {LanguageSwitcher},
  methods: {
    goHome() {
      this.$router.push({name: "home"});
    },
  },
  data() {
    return {
      items: [
        {label: 'home', to: '/home'},
        {label: 'mental-state-exams', to: '/nursing/mental-state-exams'},
      ],
    }
  }
}
</script>

<template>
  <pv-toolbar class="bg-primary" style="border-radius: 0;">
    <template #start>
      <a aria-label="HIGN Home" href="/" >
        <img src="https://hign.org/sites/default/files/2022-01/HIGN-logo-1200.png" alt="HIGN Logo" width="10%" class="mb-1">
      </a>
    </template>

    <template #end>
      <div class="flex-column">
        <router-link v-for="item in items" :key="item.label" v-slot="{navigate, href}" :to="item.to" custom>
          <pv-button :href="href" class="p-button-text text-white" @click="navigate">
            {{ $t(item.label) }}
          </pv-button>
        </router-link>
      </div>
      <language-switcher/>
    </template>
  </pv-toolbar>
</template>

<style scoped>
</style>