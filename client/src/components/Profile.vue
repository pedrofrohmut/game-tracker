<template>
  <section>
    <router-link style="position: relative; left: 22%" to="/">
      Go Back
    </router-link>

    <div v-if="loading">
      <h3>Loading...</h3>
    </div>

    <div v-if="error">
      <h3>{{ error }}</h3>
      <router-link to="/">Go Back</router-link>
    </div>

    <!-- Profile Container -->
    <div
      v-if="profileData"
      style="background-color: rgba(0,0,0,0.5)"
      class="text-white max-w-3xl mx-auto my-4 py-6 px-6 rounded"
    >
      <!-- GamerTag name/icon -->
      <div
        class="text-3xl py-3 px-4 text-center rounded mb-3 flex items-center"
        style="background-color: rgba(0,0,0,0.6);"
      >
        <img
          :src="profileData.platformInfo.avatarUrl"
          style="width: 50px;"
          class="mr-4"
          alt=""
        />
        <div>
          {{ profileData.platformInfo.platformUserId }}
        </div>
      </div>

      <!-- Grid -->
      <div class="flex">
        <div class="flex-1">
          <img
            :src="profileData.segments[1].metadata.imageUrl"
            alt=""
            class="w-full"
          />
        </div>

        <div class="flex-1">
          <ul class="text-3xl">
            <li
              class="rounded p-4 font-light mb-3"
              style="background-color: rgba(0,0,0,0.6);"
            >
              <div class="text-sm font-bold">
                Selected Legend
              </div>

              <div>
                {{ profileData.metadata.activeLegendName }}
              </div>
            </li>

            <li
              class="rounded p-4 font-light mb-3"
              style="background-color: rgba(0,0,0,0.6);"
              v-if="profileData.segments[0].stats.season2Wins"
            >
              <div class="text-sm font-bold">
                Season 2 Wins
              </div>
              <div>
                <div class="inline-block mr-2">
                  {{ profileData.segments[0].stats.season2Wins.displayValue }}
                </div>
                <div class="inline-block text-sm">
                  ({{ profileData.segments[0].stats.season2Wins.percentile }})
                </div>
              </div>
            </li>

            <li
              class="rounded p-4 font-light mb-3"
              style="background-color: rgba(0,0,0,0.6);"
              v-if="profileData.segments[0].stats.level"
            >
              <div class="text-sm font-bold">Apex Level</div>
              <p>
                {{ profileData.segments[0].stats.level.displayValue }}
                <span
                  >({{ profileData.segments[0].stats.level.percentile }}%)</span
                >
              </p>
            </li>
            <li
              class="rounded p-4 font-light mb-3"
              style="background-color: rgba(0,0,0,0.6);"
              v-if="profileData.segments[0].stats.kills"
            >
              <div class="inline-block text-sm">Lifetime Kills</div>
              <p>
                {{ profileData.segments[0].stats.kills.displayValue }}
                <span
                  >({{ profileData.segments[0].stats.kills.percentile }}%)</span
                >
              </p>
            </li>
            <li
              class="rounded p-4 font-light mb-3"
              style="background-color: rgba(0,0,0,0.6);"
              v-if="profileData.segments[0].stats.damage"
            >
              <div class="inline-block text-sm">Damage Done</div>
              <p>
                {{ profileData.segments[0].stats.damage.displayValue }}
                <span
                  >({{
                    profileData.segments[0].stats.damage.percentile
                  }}%)</span
                >
              </p>
            </li>
          </ul>
        </div>
        <!-- flex-1 -->
      </div>
      <!-- flex -->
    </div>
    <!-- Profile -->
  </section>
</template>

<script>
import axios from "axios"

export default {
  name: "Profile",
  data() {
    return {
      loading: false,
      error: null,
      profileData: null,
    }
  },
  beforeCreate() {
    document.body.className = "body-bg-no-image"
  },
  created() {
    this.loading = true
    const url = `http://localhost:5000/api/v1/apex/profiles/${this.$route.params.platform}/${this.$route.params.gamertag}`
    axios
      .get(url)
      .then(response => {
        const respData = response.data.data
        console.log(respData)
        this.profileData = respData
        this.loading = false
      })
      .catch(err => {
        this.loading = false
        this.error = err.response.data.message
        console.log(this.error)
      })
  },
}
</script>

<style></style>
