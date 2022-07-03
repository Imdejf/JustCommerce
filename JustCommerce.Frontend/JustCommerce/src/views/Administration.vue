<template>
    <div id="app" class="main">
      <div class="content-container flex">
        <div class="flex" style="margin-top: 0">
            <LeftMenu
            @isActive="onClickChild"
            :menu="this.menu"/>
        </div>
        <div class="content">
          <TopBar
          :userInfo="this.userInfo"/>
          <profile></profile>
        <aside class="page-wrapper">
          <keep-alive>
            <component v-bind:is="currentTabComponent"></component>
          </keep-alive>
        </aside>
        </div>
      </div>
    </div>
</template>

<script src='../components/Administration/Administration.js'></script>
