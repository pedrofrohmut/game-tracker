<template>
  <section class="search">
    <h1 class="text-3xl px-4 mb-4">Track Player Stats</h1>

    <form v-on:submit.prevent="handleSubmit">
      <div class="px-4">
        <label>Platform</label>
        <select
          id="platform"
          name="platform"
          class="w-full px-4 py-2 border-solid rounded mb-4 mt-2 text-gray-600"
        >
          <option value="psn">PlayStation</option>
          <option value="xbl">XBox</option>
          <option value="origin">Origin</option>
        </select>
      </div>

      <div class="px-4">
        <label>GamerTag</label>
        <input
          id="gamertag"
          type="text"
          name="text"
          v-model="gamertag"
          placeholder="Origin ID, XBox Live gamertag, PSN ID, etc"
          class="w-full px-4 py-2 border-solid rounded mb-4 mt-2 text-gray-600"
        />
      </div>

      <div class="px-4">
        <input type="submit" value="Submit" class="btn mb-4 rounded text-lg" />
      </div>
    </form>
  </section>
</template>

<script>
export default {
  name: "Search",
  data() {
    return {
      platform: "psn",
      gamertag: "",
    }
  },
  beforeCreate() {
    document.body.className = "body-bg-image"
  },
  methods: {
    handleSubmit() {
      if (!this.gamertag) {
        this.$toasted.show("Please enter a gamer tag", {
          duration: 3000,
          icon: "exclamation-circle",
        })
      } else {
        console.log("will redirect")
        this.$router.push(`/profile/${this.platform}/${this.gamertag}`)
      }
    },
  },
}
</script>

<style scoped></style>
