<template>
    <div class="dropdown dropdown-avatar intro-x w-8 h-8">
        <div class="dropdown w-8 h-8 rounded-full overflow-hidden shadow-lg image-fit zoom-in" id="dropdownMenuLink" data-bs-toggle="dropdown" aria-expanded="false" role="button">
            <img alt="Midone Tailwind HTML Admin Template" src="@/assets/avatar.jpg" />
        </div>
        <ul class="dropdown-menu" aria-labelledby="dropdownMenuLink">
            <li style="pointer-events: none;">
                <div class="dropdown-header">
                    <div class="font-medium">{{ this.$parent.userInfo.FullName }}</div>
                    <div class="text-footer">{{ $t('role.' + this.$parent.userInfo.ProfileType) }}</div>
                </div>
            </li>
            <li>
                <hr style="border-bottom:1px solid rgb(226, 232, 240)"/>
            </li>
            <li>
                <a class="dropdown-item" href="#"><i class="fa fa-user"></i> {{ $t('avatar.profile') }}</a>
            </li>
            <li><a class="dropdown-item" href="#"><i class="fa fa-lock"></i> {{ $t('avatar.resetPassword') }}</a></li>
            <li><a class="dropdown-item" href="#"><i class="fa fa-question"></i>{{ $t('avatar.help') }}</a></li>
            <li>
                <hr style="border-bottom:1px solid rgb(226, 232, 240)"/>
            </li>
            <li><a @click="logout" class="dropdown-item" href="#"><i class="fa fa-power-off"></i> {{ $t('avatar.logout') }}</a></li>
        </ul>
    </div>
</template>

<script>

export default {
  components: {
  },
  data: function () {
    return {
      user: {},
      openProfile: true
    }
  },
  methods: {
    logout: function () {
      this.$cookies.remove('Authorization')
      this.$router.push('/login')
    }
  }
}
</script>
