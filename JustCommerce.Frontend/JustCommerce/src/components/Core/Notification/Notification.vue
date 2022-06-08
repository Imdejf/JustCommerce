<template>
    <div class="dropdown intro-x mr-auto sm:mr-6" style="top:2px;">
        <div class="dropdown notification notification--bullet cursor-pointer" id="dropdownNotification" data-bs-toggle="dropdown" aria-expanded="false" role="button">
            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide notification__icon dark:text-slate-500">
                <path d="M18 8A6 6 0 006 8c0 7-3 9-3 9h18s-3-2-3-9"></path>
                <path d="M13.73 21a2 2 0 01-3.46 0"></path>
            </svg>
        </div>
        <ul class="dropdown-menu dropdown-notification" aria-labelledby="dropdownNotification">
            <li style="pointer-events: none;">
                <div class="dropdown-header">
                    <div class="font-medium-notification">{{$t('Notification')}}</div>
                </div>
            </li>
            <li style="margin-bottom:20px;">
            </li>
            <li>
                <div class="flex" style="margin-bottom: 8px">
                    <a>Temat</a>
                    <div style="margin:0 10px 0 auto; ">03:20 PM</div>
                </div>
                <div class="flex">
                    Rejestracja użytkownika
                </div>
            </li>
        </ul>
    </div>
</template>
