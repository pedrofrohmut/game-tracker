<template>
  <div class="container mx-auto">
    <Header />
    <Search />
  </div>
</template>

<script>
import Header from "./components/Header"
import Search from "./components/Search"

export default {
  name: "app",
  components: {
    Header,
    Search,
  },
}
</script>

<style>
*,
*::after,
*::before {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}

:root {
  font-size: 16px;
  --mainRed: #953036;
}

body {
  min-height: 100vh;
  overflow-x: hidden;
  background-color: var(--mainRed);
  color: #fff;
  font-family: Arial, sans-serif;
  line-height: 1.6;
  font-weight: 400;
  text-align: left;
}

p {
  text-align: justify;
}

a {
  color: #fff;
  text-decoration: none;
}

ul {
  list-style: none;
}

.body-bg-no-image {
  background: var(--mainRed);
}

.body-bg-image {
  background: var(--mainRed) url("./assets/octane.png") no-repeat top center;
}

.search {
  background: rgba(0, 0, 0, 0.5);
  border: 4px solid #fff;
  margin-top: 1rem;
  padding: 2rem;
}

.btn {
  display: inline-block;
  background-color: var(--mainRed);
  color: #fff;
  padding: 0.4rem 0.8rem;
  border: none;
  cursor: pointer;
  outline: none;
  margin-top: 1rem;
}
</style>
