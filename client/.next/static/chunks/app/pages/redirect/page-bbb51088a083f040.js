(self.webpackChunk_N_E=self.webpackChunk_N_E||[]).push([[32],{1570:function(e,t,o){Promise.resolve().then(o.bind(o,4953))},7907:function(e,t,o){"use strict";var r=o(5313);o.o(r,"usePathname")&&o.d(t,{usePathname:function(){return r.usePathname}}),o.o(r,"useSearchParams")&&o.d(t,{useSearchParams:function(){return r.useSearchParams}})},4953:function(e,t,o){"use strict";o.r(t),o.d(t,{default:function(){return i}});var r=o(3827),n=o(4090),c=o(8021),s=e=>{let t=!0,[o,s]=(0,n.useState)();return(0,n.useEffect)(()=>{(async()=>{try{if(e.code&&t){console.log(e.code),t=!1;let r=await fetch("".concat(c.QP,"/user/login?code=").concat(e.code),{method:"GET"});r.ok||console.error("Error en la solicitud: ".concat(r.statusText));let n=await r.json();localStorage.setItem("token",n.token),localStorage.setItem("rtoken",n.refreshToken),localStorage.setItem("email",n.user.email),localStorage.setItem("user",JSON.stringify(n.user)),null==o&&s(n.user),console.log("Data:",n)}}catch(e){console.error("Error al obtener el usuario:",e)}})()},[e.code]),(0,r.jsx)("div",{children:o?(0,r.jsxs)("h1",{children:["Te Logueaste con exito ",null==o?void 0:o.name]}):(0,r.jsx)("h1",{children:"Loading..."})})},a=e=>{let t=!0,[o,s]=(0,n.useState)();return(0,n.useEffect)(()=>{(async()=>{try{if(e.code&&t){console.log(e.code),t=!1;let r=await fetch("".concat(c.QP,"/user?code=").concat(e.code),{method:"POST"});r.ok||console.error("Error en la solicitud: ".concat(r.statusText));let n=await r.json();localStorage.setItem("token",n.token),localStorage.setItem("rtoken",n.refreshToken),localStorage.setItem("email",n.user.email),localStorage.setItem("user",JSON.stringify(n.user)),null==o&&s(n.user),console.log("Data:",n)}}catch(e){console.error("Error al obtener el usuario:",e)}})()},[e.code]),(0,r.jsx)("div",{children:o?(0,r.jsxs)("h1",{children:["Te Logueaste con exito ",null==o?void 0:o.name]}):(0,r.jsx)("h1",{children:"Loading..."})})},l=o(7907);let u=()=>{let[e,t]=(0,n.useState)(0),o=(0,l.useSearchParams)().get("code"),c=(0,l.useSearchParams)().get("signin");return(0,n.useEffect)(()=>{c?t(2):t(1)},[c]),(0,r.jsx)("div",{children:1==e?(0,r.jsx)("div",{children:(0,r.jsx)(s,{code:o})}):2==e?(0,r.jsx)("div",{children:(0,r.jsx)(a,{code:o})}):null})};function i(){return(0,r.jsx)(n.Suspense,{fallback:(0,r.jsx)("div",{children:"Loading..."}),children:(0,r.jsx)(u,{})})}},8021:function(e,t,o){"use strict";o.d(t,{Cx:function(){return a},He:function(){return u},IC:function(){return s},QP:function(){return r},u8:function(){return n},yK:function(){return c},yO:function(){return l}});let r="http://localhost:5019/api",n="https://PORTAFOLIO_API.com",c="dev-v2roygalmy6qyix2.us.auth0.com",s="offline_access",a="FiGgFZqBNRTXMtroNlRxerrS9FEwWca8",l="code",u="http://localhost:3000"}},function(e){e.O(0,[971,69,744],function(){return e(e.s=1570)}),_N_E=e.O()}]);