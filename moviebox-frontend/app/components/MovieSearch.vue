<script setup>
import { useDebounceFn } from '@vueuse/core'

const searchTerm = ref('')
const open = ref(false)

const fetchSearchResults = useDebounceFn(() => {
  console.log(`Searching for: ${searchTerm.value}`)
  return $fetch(`/api/movies/search?title=${searchTerm.value}`)
}, 500)

const { data: searchResults, status, refresh, clear } = useAsyncData(
  'search-results',
  fetchSearchResults, 
  { immediate: false }
)

watch(searchTerm, (value) => {
  if (value.trim().length === 0) {
    clear()
  } else {
    console.log(`Searching for: ${value}`)
    refresh()
  }
})

const groups = computed(() => {
  console.log('searchResults.value', searchResults.value)
  return [
    {
      id: 'movies',
      title: 'Movies',
      ignoreFilter: true,
      items: [

      ]
    },
    {
      id: 'reviews',
      title: 'Reviews',
      ignoreFilter: true,
      items: [

      ]
    }
  ]
})
</script>

<template>
  <UModal
    v-model:open="open"
    title="Movie Search"
  >
    <UButton
      label="Search for a movie..."
      icon="i-lucide-search"
      color="neutral"
      variant="outline"
      @click="open = true"
    />
    <template #content>
      <UCommandPalette 
        v-model:search-term="searchTerm"
        :groups="groups"
        placeholder="Enter a movie title..."
        :autofocus="true"
        :loading="status === 'pending'"
        close
        @update:open="open = $event"
      >
        <template #empty>
          <div>Search for a movie by title</div>
        </template>
      </UCommandPalette>
    </template>

  </UModal>
</template>