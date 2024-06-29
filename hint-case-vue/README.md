# Project Name

## Summary
Add project summary here

## Developer Information
- Developed by: [Alex Avila Asto](https://github.com/Ryzeon)

## Features
- Rest Client with Axios
- Simulate API with JSON Server
- PrimeVue as UI Library
- In-app navigation with Vue Router
- Responsive layout with PrimeFlex
- Reusable components
- Internationalization with Vue I18n

## Dependencies
- Node.js
- Vue
- Axios
- PrimeVue
- PrimeFlex
- Vue Router
- Vue I18n
- JSON Server

## Project setup
```bash
npm install
```
### Compiles and hot-reloads for development
```bash
npm run dev
```
### Compiles and minifies for production
```bash
npm run build
```
### Run JSON Server
```bash
cd server
sh start.sh
```
### Getting started with i18n
```bash
npm install vue-i18n@9
mkdir src/locales
echo "{\n}" > src/locales/en.json
echo "{\n}" > src/locales/es.json
echo '
import en from "./locales/en.json";
import es from "./locales/es.json";
import {createI18n} from "vue-i18n";

const i18n = createI18n({
    legacy: false,
    locale: 'en',
    globalInjection: true,
    messages: {en, es}
});

export default i18n;
' > src/i18n.js
```

```js
// i18n
import i18n from "./i18n.js";

// Add i18n plugin
app.use(i18n);
```