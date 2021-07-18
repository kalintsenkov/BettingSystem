# base image
FROM node:12.2.0 as build

# set working directory
WORKDIR /app

# add `/app/node_modules/.bin` to $PATH
ENV PATH /app/node_modules/.bin:$PATH

# install and cache app dependencies
COPY package.json /app/package.json
RUN npm install

# add app
COPY . /app

# generate build
RUN npm run build

# base image
FROM nginx:1.16.0-alpine

# Remove default Nginx website
RUN rm -rf /usr/share/nginx/html/*

# Copy Nginx configuration
COPY ./nginx.conf /etc/nginx/nginx.conf

# copy artifact build from the 'build environment'
COPY --from=build /app/build /usr/share/nginx/html

# expose port 80
EXPOSE 80

# run nginx
CMD ["nginx", "-g", "daemon off;"]