<template>
    <div class="top-bar">
        <nav aria-label="breadcrumb" class="-intro-x mr-auto hidden sm:flex">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="#">Application</a></li>
                <li class="breadcrumb-item active" aria-current="page">Dashboard</li>
            </ol>
        </nav>
        <Search/>
        <Notification/>
        <Avatar/>
    </div>
</template>

<script>
import Search from '@/components/Core/Search/Search.vue'
import Notification from '@/components/Core/Notification/Notification.vue'
import Avatar from '@/components/Core/Avatar/Avatar.vue'

export default {
  components: {
    Search,
    Notification,
    Avatar
  }
}
</script>
