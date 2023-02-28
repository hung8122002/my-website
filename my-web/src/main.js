import { createApp } from "vue";
import App from "./App.vue";
import MISAEnum from "./js/enum";
import MISAResource from "./js/resource";
import commonJS from "./js/common";
import method from "./js/method";
import MIconButton from "./components/iconBtn/MIconButton.vue";
import MInputMoney from "./components/inputMoney/MinputMoney.vue";
import XLSX from 'xlsx';
import _ from "lodash";
import axios from "axios";

const app = createApp(App);

app.use(XLSX);
app.config.globalProperties.$resource = MISAResource;
app.config.globalProperties.enum = MISAEnum;
app.config.globalProperties.commonJS = commonJS;
app.config.globalProperties.axios = axios;
app.config.globalProperties.method = method;
app.config.globalProperties._ = _;
app.component("MIconButton", MIconButton);
app.component("MInputMoney", MInputMoney);
app.mount("#app");
