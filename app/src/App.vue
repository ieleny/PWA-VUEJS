<template>
  <div id="app">
    <header>
      <b-navbar toggleable="md" type="light" variant="light">
        <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
        <b-navbar-brand to="/" class="logo">
        </b-navbar-brand>
      </b-navbar>
    </header>
    <main>
      <router-view></router-view>
    </main>
  </div>
</template>

<script>

  export default {
    name: 'app',
    data () {
      return {
        user: null
      }
    },
    methods: {
      login () {

      },
      async logout () {

      }
    }
  }
</script>

