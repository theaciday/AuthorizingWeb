import React, { useEffect, useState } from 'react';
//import cookies from 'browser-cookies';
//cookies.get('firstName');

const Home = () => {
    function getCookie(cname) {
        var name = cname + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) == 0) {
                return c.substring(name.length, c.length);
            }
        }
        return "";
    }
    const token = getCookie('token')
    const [userName, setUserName] = useState('');
    console.log(getCookie('token'));
    useEffect(() => {
        (
            async () => {
                const response = await fetch('https://localhost:5001/api/user/user', {
                    headers: { 'Content-Type': 'application/json', 'Authorization': `Bearer ${token}` },
                    credentials: 'include',
                });
                
                const context = await response.json();
                setUserName(context.name);
                
            }

        )();
    });

    return (
        <div>
            {userName ? 'Welcome' + userName :'Unauthorized'}
           {/* {'Welcome' + userName}*/}
        </div>
    );
};
export default Home;