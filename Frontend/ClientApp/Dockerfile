FROM node
WORKDIR ./node-app
ENV PATH /node-app/node_modules/.bin:$PATH
COPY package.json .
COPY package-lock.json .
RUN npm i
COPY . .
CMD ["npm", "run", "start"]