# FROM node:10.13-alpine
# ENV NODE_ENV development
# WORKDIR /usr/src/app
# COPY ./src/web/package.json .
# COPY ./src/web/package-lock.json .
# COPY ./src/web/ .
# RUN ls -R
# RUN npm install
# #--production --silent 
# #&& mv node_modules ../
# COPY . .
# RUN npm build
# EXPOSE 8080
# CMD npm run start

FROM node:lts-alpine as build-stage
WORKDIR /app
COPY ./src/web/package*.json ./
RUN npm install
COPY ./src/web/ .
RUN npm run build

# estágio de produção
FROM nginx:stable-alpine as production-stage
COPY --from=build-stage /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]