<template>
  <header>
    <img :src="image" class="pb-4" />
  </header>
</template>

<script>
export default {
  name: "Header",
  data: () => ({
    image: require("@/assets/logo.png")
  })
};
</script>

<style scoped>
img {
  width: 300px;
  display: block;
  margin: auto;
}

@media (min-width: 700px) {
  img {
    display: inline-block;
    margin: 0;
  }
}
</style>
