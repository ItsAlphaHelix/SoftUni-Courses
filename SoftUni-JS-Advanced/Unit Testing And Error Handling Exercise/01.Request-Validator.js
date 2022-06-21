function solveTheProblem(obj) {

    const validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    const validVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    const urlRegex = /^[\w\.]+$/gm;
    const messageRegex = /^([^<>\\&'"]*)$/g;

    if (!obj.hasOwnProperty('method') || !validMethods.includes(obj.method)) {

        throw new Error(`Invalid request header: Invalid Method`)

    }
    if (!obj.hasOwnProperty('uri') || !urlRegex.test(obj.uri)) {

        throw new Error(`Invalid request header: Invalid URI`)
    }
    if (!obj.hasOwnProperty('version') || !validVersions.includes(obj.version)) {

        throw new Error(`Invalid request header: Invalid Version`)

    }
    if (!obj.hasOwnProperty('message') || !messageRegex.test(obj.message)) {

        throw new Error(`Invalid request header: Invalid Message`)
    }

    return obj;
}
try {
  let result = solveTheProblem({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
  });

      console.log(result)

} catch (message) {
    console.log(message);
}