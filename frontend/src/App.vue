<script setup>
import { ref } from 'vue'

const url = ref('')
const htmlContent = ref('')
const loading = ref(false)
const error = ref(null)

const fetchHtml = async () => {
  if (!url.value) {
    error.value = 'Please enter a URL'
    return
  }

  loading.value = true
  error.value = null
  htmlContent.value = ''

  try {
    const apiUrl = `${import.meta.env.VITE_API_BASE_URL}/api/crawl?url=${encodeURIComponent(url.value)}`
    const response = await fetch(apiUrl)
    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`)
    }
    htmlContent.value = await response.text()
  } catch (e) {
    error.value = e.message
  } finally {
    loading.value = false
  }
}
</script>

<template>
  <div id="app">
    <header>
      <h1>HTML Crawler</h1>
    </header>
    <main>
      <div class="input-container">
        <input type="url" v-model="url" placeholder="Enter a valid URL" />
        <button @click="fetchHtml" :disabled="loading">
          {{ loading ? 'Fetching...' : 'Fetch HTML' }}
        </button>
      </div>
      <div v-if="error" class="error-message">
        <p>Error: {{ error }}</p>
      </div>
      <div v-if="htmlContent" class="html-container">
        <h2>Crawled HTML Content:</h2>
        <pre>{{ htmlContent }}</pre>
      </div>
    </main>
  </div>
</template>

<style scoped>
#app {
  max-width: 800px;
  margin: 0 auto;
  padding: 2rem;
  font-family: sans-serif;
}

header {
  text-align: center;
  margin-bottom: 2rem;
}

.input-container {
  display: flex;
  gap: 1rem;
  margin-bottom: 1rem;
}

input[type="url"] {
  flex-grow: 1;
  padding: 0.5rem;
  font-size: 1rem;
}

button {
  padding: 0.5rem 1rem;
  font-size: 1rem;
  cursor: pointer;
}

.error-message {
  color: red;
  margin-bottom: 1rem;
}

.html-container {
  border: 1px solid #444;
  padding: 1.5rem;
  white-space: pre-wrap;
  word-wrap: break-word;
  background-color: #282c34; /* 深色背景 */
  color: #abb2bf; /* 淺色文字 */
  border-radius: 8px; /* 圓角 */
  overflow-x: auto; /* 內容過長時顯示滾動條 */
}

.html-container h2 {
  color: #61afef; /* 標題使用不同的顏色 */
  border-bottom: 1px solid #444;
  padding-bottom: 0.5rem;
  margin-top: 0;
}
</style>