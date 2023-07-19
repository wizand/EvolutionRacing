<script>
	import { Alert } from 'flowbite-svelte';
	import { Button } from 'flowbite-svelte';
	import { Label, Input } from 'flowbite-svelte';
	

	function onConnectToServerButtonClicked() 
	{
		gameId = "asd-asd-123-123";
		gameConnectionMessage = "Connected to server " + serverInput + ". Game id: " + gameId;
	}

	let serverInput = "127.0.0.1";
	let gameId = "";
	let gameConnectionMessage = "Not connected.";
</script>

<div class="p-8">

	<div id="container" class="ml-20 mt-20">
		<Label for='server-ip-input' class='block mb-2'>Server ip:</Label>
  		<Input id="server-ip-input" size="lg" placeholder="127.0.0.1" bind:value={serverInput} />
		<Button on:click={onConnectToServerButtonClicked}>Connect to server</Button>

		<Label>Game connection status: {gameConnectionMessage}</Label>

	</div>
	
</div>