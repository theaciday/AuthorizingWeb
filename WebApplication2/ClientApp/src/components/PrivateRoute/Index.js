import React, { Fragment } from 'react';
import { Redirect, useRouteMatch } from 'react-router-dom';
import { getAllowedRoutes, isLoggedIn } from '../../utils/index';
import { PrivateRoutesConfig } from '../../Config/PrivateRoutesConfig';
import NavMenu from '../../NavMenu';
import MapAllowedRoutes from 'routes/MapAllowedRoutes';
