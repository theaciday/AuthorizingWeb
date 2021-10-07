const request = async (url, params = {}, body) => {
    const urll = new URL(`https://localhost:44317/api/${url}`)
    if (params.queryParams) {
        Object.keys(params.queryParams).forEach(key => urll.searchParams.append(key, params.queryParams[key]))
    }
    const token = localStorage.getItem('token')
    const response = await fetch(urll, {
        headers: { 'Content-type': 'application/json', ...(token && { 'Authorization': token }) },
        ...params,
        ...(body && { body: JSON.stringify(body) })
    });
    const text = await response.text();

    const data = text && JSON.parse(text)

    if (!response.ok) {
        if (response.status === 401) {
            // auto logout if 401 response returned from api
            //logout();
            //location.reload(true);
        }

        const error = (data && data.message) || response.statusText;
        return Promise.reject(error);
    }
    return data;
}
export default request;

/*request('adsfasfd', { method: 'POST' }, {bla: '123213'})*/ 