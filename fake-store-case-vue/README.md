### Fake store case

Usted forma parte del staff de Zoo Fake, inc. (https://freetestapi.com/api/v1/) Con el fin de promover sus
servicios de desarrollo de soluciones de software, desean elaborar un proyecto que brinde información
sobre los animales habitantes del zoo. Ellos exponen dicha información a través de un API para el
proyecto, que es de código abierto y de uso gratuito.
Para ello, le encargan elaborar una aplicación web que liste los habitantes animales (animals) del
zoológico, toda la información la obtendrá accediendo al endpoint:
https://freetestapi.com/api/v1/animals?limit=10
Para el desarrollo web de lado web frontend, se ha seleccionado JavaScript como lenguaje de
programación y Vue como Frontend Framework.
Se le encarga el desarrollo de una aplicación web que implemente las siguientes características:
- [ ] La aplicación debe presentar en la vista home un Toolbar en la parte superior, con el título “Fake
Zoo API Showcase”.
- [ ] La aplicación debe presentar debajo una vista “Animals” con cards para los animales.
- [ ] Para cada card, la información del animal a mostrar incluye: name, image, habitat, description, y
family. El url de la imagen está en la propiedad image del objeto.
- [ ] El usuario puede calificar el interés de conocer un animal mediante un control rating, debe estar
ubicada en el footer del card
- [ ] La aplicación debe presentar en la parte inferior de la vista “Animal”, una sección de footer con
la información “Copyright © 2024 Fake Store, inc. All rights reserved.” en la primera línea.
Además debe incluir en la segunda línea del footer la información “Developed by“ y los datos del
Developer (considérese a usted como autor, indicando código, nombre y apellido.)

El equipo de IT de su cliente tomará en cuenta no solo el cumplimiento de las características
funcionales, sino el diseño de interfaz de usuario, así como la estructura del proyecto, aplicación de
convenciones de nomenclatura de objetos de programación en inglés, convenciones de nomenclatura
de Vue.js, organización y eficiencia del código. Igualmente se tomará en cuenta la aplicación de patrones
de diseño.
<br>
Restricciones técnicas: Debe generar el proyecto con Vite y utilizar Vue 3. El equipo requiere que la
interfaz de usuario esté basada en Material Design utilizando la biblioteca de componentes de UI
PrimeVue, mientras que para la comunicación con el backend debe apoyarse en axios
(https://github.com/axios/axios). Debe incluir ARIA atributes en las vistas. La interfaz de usuario debe
mostrar los textos en inglés. Aplique buenas prácticas y convenciones aplicadas en clase para
nomenclatura lógica y física de clases y componentes. El proyecto de aplicación debe poder aperturarse
sin problemas en JetBrains WebStorm.
Para la nomenclatura física de componentes, clases e interfaces utilice kebab-case. Aplique en los
nombres físicos sufijos que indiquen el tipo de elemento: .component.vue, .service.js, .entity.js. El sufijo
Página 3 de 4
component no debe ser parte del nombre del componente cuando se use en templates (Por ejemplo
user-list.component.vue debería utilizarse en código de template como <user-list></user-list>).
Para la nomenclatura de componentes de PrimeVue dentro de los templates utilice kebab-case. Asigne
el prefijo pv- al momento de incorporar su uso en el proyecto (Por ejemplo, pv-card). Comente los
archivos de código fuente elaborados por usted, incluyendo summary con el propósito y author con su
nombre y apellido.

Fuera del alcance:
* Sidebar
* Internationalization
* Routing

Referencias:
* https://fakestoreapi.com/
* https://router.vuejs.org/
* https://router.vuejs.org/installation.html
* https://primevue.org/installation
* https://primevue.org/button
* https://primevue.org/toolbar
* https://primevue.org/toast
* https://primeflex.org/installation
* https://primeflex.org/gridsystem
* https://primeflex.org/flex
* https://axios-http.com/docs/intro

## Getting Started with Vue

- Fist, create a project with Vite + Vue
- Now we need to install primevue, follow the instructions on the [PrimeVue](https://primevue.org/vite) website

```bash
npm i primevue && npm i primeicons && npm i primeflex
```

- Now import in main.js here example

```javascript
// PrimeVue
import PrimeVue from "primevue/config";

// PrimeVue services
import ConfirmationService from "primevue/confirmationservice";
import DialogService from "primevue/dialogservice";
import ToastService from "primevue/toastservice";

// Prime vue components
import Button from "primevue/button";
import Card from "primevue/card";
import Column from "primevue/column";
import ConfirmDialog from "primevue/confirmdialog";
import Checkbox from "primevue/checkbox";
import DataTable from "primevue/datatable";
import Dialog from "primevue/dialog";
import Dropdown from "primevue/dropdown";
import FileUpload from "primevue/fileupload";
import FloatLabel from "primevue/floatlabel";
import IconField from "primevue/iconfield";
import InputIcon from "primevue/inputicon";
import InputText from "primevue/inputtext";
import InputNumber from "primevue/inputnumber";
import Menu from "primevue/menu";
import Rating from "primevue/rating";
import Row from "primevue/row";
import Sidebar from "primevue/sidebar";
import Tag from "primevue/tag";
import Textarea from "primevue/textarea";
import Toolbar from "primevue/toolbar";
import Toast from "primevue/toast";

// PrimeIcons
import 'primeicons/primeicons.css';

// PrimeFlex
import 'primeflex/primeflex.css';

// Theme
import 'primevue/resources/themes/md-light-indigo/theme.css';
import 'primevue/resources/primevue.min.css';

createApp(App)
    .use(PrimeVue, {ripple: true})
    .use(ConfirmationService)
    .use(DialogService)
    .use(ToastService)
    .component("pv-button", Button)
    .component("pv-card", Card)
    .component("pv-column", Column)
    .component("pv-confirm-dialog", ConfirmDialog)
    .component("pv-checkbox", Checkbox)
    .component("pv-data-table", DataTable)
    .component("pv-dialog", Dialog)
    .component("pv-dropdown", Dropdown)
    .component("pv-file-upload", FileUpload)
    .component("pv-float-label", FloatLabel)
    .component("pv-icon-field", IconField)
    .component("pv-input-icon", InputIcon)
    .component("pv-input-text", InputText)
    .component('pv-input-number', InputNumber)
    .component("pv-menu", Menu)
    .component("pv-rating", Rating)
    .component("pv-row", Row)
    .component("pv-sidebar", Sidebar)
    .component("pv-tag", Tag)
    .component('pv-textarea', Textarea)
    .component("pv-toolbar", Toolbar)
    .component('pv-toast', Toast)

    .mount('#app')
```

- Axios tmb xd

```bash
npm i axios
```

# Vue 3 + Vite

This template should help get you started developing with Vue 3 in Vite. The template uses Vue 3 `<script setup>` SFCs,
check out the [script setup docs](https://v3.vuejs.org/api/sfc-script-setup.html#sfc-script-setup) to learn more.

## Recommended IDE Setup

- [VS Code](https://code.visualstudio.com/) + [Vue - Official](https://marketplace.visualstudio.com/items?itemName=Vue.volar) (
  previously Volar) and disable Vetur
