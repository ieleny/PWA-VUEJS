// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'

import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

import VueSimpleAlert from "vue-simple-alert"

import './assets/css/css.css'

Vue.config.productionTip = false

Vue.use(BootstrapVue);
Vue.use(VueSimpleAlert);

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  template: '<App/>',
  components: { App },
  //Metodos Gerais
  methods: {

    removeNonDigits(value){
      return parseInt(value.replace(/[.,]/g,''));
    },

    dateNow(data = null){
      var currentDate = new Date(data);
      return new Date().toJSON().slice(0,10).replace(/-/g,'/');
    }

  }
  
})
