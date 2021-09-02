import React, { Component, useEffect } from 'react';


const Home = () => {
    useEffect(() => {
        (
            async () => {
                await fetch('https://localhost:5001/api/user/getuser', {
                    headers: { 'Content-Type': 'application/json' },
                    credentials: 'include',
                });
            }
        )();
    });

    return (
        <div>
            Home
            </div>
        )
};
export default Home;