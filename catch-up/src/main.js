import {createApp} from 'vue'
import './style.css'
import App from './App.vue'
import PrimeVue from "primevue/config";
import Card from "primevue/card";
import Button from "primevue/button";
import SelectButton from "primevue/selectbutton";
import Avatar from "primevue/avatar";
import Menu from "primevue/menu";
import Menubar from "primevue/menubar";
import Toolbar from "primevue/toolbar";

// add prime flex
import 'primeflex/primeflex.css '

// add prime indigo
import 'primevue/resources/themes/md-light-indigo'

// add prime icons
import 'primeicons/primeicons.css'
import Sidebar from "primevue/sidebar";


const app = createApp(App);

// Initialize primevue plugin.
app.use(PrimeVue, {
    ripple: true,
})
    .component('pv-card', Card)
    .component('pv-sidebar', Sidebar)
    .component('pv-button', Button)
    .component('pv-select-button', SelectButton)
    .component('pv-avatar', Avatar)
    .component('pv-menu', Menu)
    .component('pv-menubar', Menubar)
    .component('pv-toolbar', Toolbar)

app.mount('#app')
