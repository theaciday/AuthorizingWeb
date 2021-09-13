
const request = async (url, params = {}, body) => {
    const token = localStorage.getItem('token')
    const request = await fetch(`https://localhost:5001/api/${url}`, {
        headers: { 'Content-type': 'application/json', ...(token && { 'Authorization': token }) },
        ...params,
        ...(body && { body: JSON.stringify(body) })
    });
    return await request.json();
}
export default request;

/*request('adsfasfd', { method: 'POST' }, {bla: '123213'})*/