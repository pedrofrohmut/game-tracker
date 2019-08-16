<template>
  <section class="search">
    <h1 class="text-5xl">Track Player Stats</h1>

    <form v-on:submit.prevent="handleSubmit">
      <div class="form-group">
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

      <div class="form-group">
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

      <div class="form-group">
        <input type="submit" value="Submit" class="btn rounded text-lg" />
      </div>
    </form>
  </section>
</template>

<script>
export default {}
</script>

<style scoped></style>
