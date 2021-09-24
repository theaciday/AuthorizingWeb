import React, { useEffect } from 'react';
import userActions from '../../actions/user.actions';
import { useDispatch, useSelector } from 'react-redux';

const Home = () => {
   
    const user = useSelector((state) => {
        return state.authentication.user})
    return (
        <div>
            {user.firstName ? 'Welcome' + user.firstName : <div>'Hello,stranger!'
                Please,login or register </div>}
        </div>
    );
};
export default Home;