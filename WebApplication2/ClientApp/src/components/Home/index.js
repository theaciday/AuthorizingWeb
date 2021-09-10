import React, { useEffect, useState } from 'react';
//import cookies from 'browser-cookies';
//cookies.get('firstName');

const Home = () => {
   
    
    const [userName, setUserName] = useState('');
    useEffect(() => {
        (
            async () => {
                const token = localStorage.getItem('token')
                const response = await fetch('https://localhost:5001/api/user/user', {
                    headers: { 'Content-Type': 'application/json', 'Authorization': `${token}` },
                    credentials: 'include',
                });
                const context = await response.json();
                setUserName(context.name);
            }

        )();
    });

    return (
        <div>
            {userName ? 'Welcome' + userName : 'Hello,stranger!'}
            Please,login or register 
           {/* {'Welcome' + userName}*/}
        </div>
    );
};
export default Home;