<template>
  <div id="app">
    <h1 class="title">Portal of Buying Movie Tickets</h1>
    <UserComponentVue />
    <FilmComponentVue msg="Portal of buying movie tickets" />
  </div>
</template>

<script setup>
import FilmComponentVue from './components/OrderComponent.vue';
import UserComponentVue from './components/UserComponent.vue';
</script>

<style scoped>
.title {
  font-size: 36px;
  font-weight: bold;
  color: #0000ff;
}
</style>
