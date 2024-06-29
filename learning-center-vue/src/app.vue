<script>
  export default {
    name: 'app',
    title: 'ACME Learning Center',
    data() {
      return {
        drawer: false,
        items: [
          { label: 'Home', to: '/home'},
          { label: 'Tutorials', to: '/tutorials' },
          { label: 'About', to: '/about'}
        ],
      }
    },
    methods: {
      toggleDrawer() {
        this.drawer = !this.drawer;
      }
    }
  }
</script>

<template>
  <pv-toast/>
  <header>
    <pv-toolbar class="bg-primary">
      <template #start>
        <pv-button class="p-button-text text-white" icon="pi pi-bars" @click="toggleDrawer"/>
        <h3>ACME Learning Center</h3>
      </template>
      <template #end>
        <div class="flex-column">
          <router-link v-for="item in items" :key="item.label" v-slot="{navigate, href}" :to="item.to" custom>
            <pv-button :href="href" class="p-button-text text-white" @click="navigate">{{ item.label }}</pv-button>
          </router-link>
        </div>
      </template>
    </pv-toolbar>
  </header>
  <pv-sidebar v-model:visible="drawer"/>
  <router-view/>
</template>

