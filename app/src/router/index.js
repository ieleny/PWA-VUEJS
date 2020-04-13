
import Vue from 'vue'
import Router from 'vue-router'
import Hello from '@/components/Hello'
import Products from '@/components/Products'

Vue.use(Router)

export default new Router
({

  routes: [
    {
      path: '/',
      name: 'Hello',
      component: Hello
    },
    {
      path: '/Products',
      name: 'Products',
      component: Products
    },
    {
      path: '/Products/:id',
      name: 'Products',
      component: Products
    },
  ]

  
})
