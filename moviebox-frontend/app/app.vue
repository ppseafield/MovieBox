<script setup lang="ts">
import MovieSearch from './components/MovieSearch.vue'

</script>

<template>
  <UApp>
    <UHeader>
      <template #left>
        MovieBox
      </template>

      <template #right>
        <MovieSearch />
      </template>
    </UHeader>

    <UMain>
      <NuxtPage />
    </UMain>


    <UFooter>
      <template #left>
        <p class="text-sm text-(--ui-text-muted)">
          Copyright © {{ new Date().getFullYear() }}
        </p>
      </template>
    </UFooter>
  </UApp>
</template>